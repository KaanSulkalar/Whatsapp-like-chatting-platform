import socket
import threading
from crypto_utils import *

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.bind(('0.0.0.0', 12345))
server.listen()

clients = []
session_keys = {}
usernames = {}

rsa_private, rsa_public = generate_rsa_keys()

def broadcast_system_message(text):
    for client in clients:
        try:
            msg = f"SYSTEM||{text}".encode()
            encrypted = des_encrypt(session_keys[client], msg)
            client.send(encrypted)
        except:
            continue

def update_user_list():
    user_list = ",".join(usernames.values())
    for client in clients:
        try:
            msg = f"SYSTEM||{user_list}".encode()
            encrypted = des_encrypt(session_keys[client], msg)
            client.send(encrypted)
        except:
            continue

def handle_client(conn, addr):
    print(f"[NEW CONNECTION] {addr} connected.")

    conn.send(rsa_public)

    try:
        encrypted_session = conn.recv(1024)
        decrypted_session = rsa_decrypt(rsa_private, encrypted_session)
        session_keys[conn] = decrypted_session
        print("[SESSION KEY REGISTERED]")
    except Exception as e:
        print("[SESSION KEY INVALID]", e)
        conn.close()
        return

    try:
        data = conn.recv(4096)
        decrypted = des_decrypt(session_keys[conn], data).decode()
        if decrypted.startswith("USER||"):
            username = decrypted.split("||")[1]
            usernames[conn] = username
            print(f"[USERNAME] {username} connected.")
            update_user_list()
            broadcast_system_message(f"{username} sohbete katıldı.")
    except Exception as e:
        print("[USERNAME ERROR]", e)
        conn.close()
        return

    while True:
        try:
            data = conn.recv(4096)
            if not data:
                break

            decrypted = des_decrypt(session_keys[conn], data)
            username = usernames.get(conn, "Anonim")
            raw_text = decrypted.decode(errors="ignore")

            if raw_text.startswith(username + ":"):
                message = raw_text
            else:
                message = f"{username}: {raw_text}"

            print(f"[MESSAGE] {message}")

            with open("chatlog.txt", "a", encoding="utf-8") as log_file:
                log_file.write(message + "\n")

            for client in clients:
                try:
                    encrypted = des_encrypt(session_keys[client], message.encode())
                    client.send(encrypted)
                except:
                    continue

        except Exception as e:
            print(f"[ERROR] {e}")
            break

    if conn in clients:
        clients.remove(conn)
    if conn in session_keys:
        session_keys.pop(conn)
    if conn in usernames:
        name = usernames.pop(conn)
        update_user_list()
        broadcast_system_message(f"{name} sohbetten ayrıldı.")
    conn.close()

print("[SERVER STARTED]")
while True:
    conn, addr = server.accept()
    clients.append(conn)
    thread = threading.Thread(target=handle_client, args=(conn, addr))
    thread.start()