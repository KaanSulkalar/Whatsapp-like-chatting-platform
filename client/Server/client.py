
import socket
from crypto_utils import *

client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
client.connect(('127.0.0.1', 12345))

rsa_public = client.recv(2048)
session_key = get_random_bytes(8)
client.send(rsa_encrypt(rsa_public, session_key))

print("[CONNECTED TO SERVER]")

def send_message():
    while True:
        msg = input("Message: ").encode()
        encrypted = des_encrypt(session_key, msg)
        signed = sign_message(private_key, msg)
        client.send(encrypted + b'||' + signed)

def receive_message():
    while True:
        data = client.recv(4096)
        encrypted, signature = data.split(b'||')
        decrypted = des_decrypt(session_key, encrypted)
        if verify_signature(public_key, decrypted, signature):
            print(f"[Verified] {decrypted.decode()}")
        else:
            print("[Invalid Signature]")

private_key, public_key = generate_rsa_keys()

import threading
threading.Thread(target=send_message).start()
threading.Thread(target=receive_message).start()
