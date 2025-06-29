
from flask import Flask, render_template_string

app = Flask(__name__)

@app.route("/")
def dashboard():
    return render_template_string("""
    <h1>Sysadmin Dashboard</h1>
    <p>Server running...</p>
    <p>Session Key Status: Active</p>
    <p>Connected Clients: Check server logs</p>
    """)

if __name__ == "__main__":
    app.run(host='0.0.0.0', port=5000)
