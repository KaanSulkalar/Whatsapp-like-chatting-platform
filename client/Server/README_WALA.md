
# WALA - WhatsApp-Like Application

## Overview
WALA is a secure chat application designed as a term project for CMSE456/CMPE455. It uses DES encryption, RSA key exchange, and digital signatures for secure communication between clients. It also includes a Sysadmin dashboard for server monitoring.

## Components
- `server.py`: Handles client connections, manages session key exchanges, and forwards messages.
- `client.py`: Connects to the server, sends and receives encrypted and signed messages.
- `crypto_utils.py`: Provides cryptographic functions (DES, RSA, digital signatures).
- `admin_dashboard.py`: Flask-based web dashboard for Sysadmin monitoring.

## Prerequisites
- Python 3.11 or higher
- Install required Python packages:
  ```bash
  pip install pycryptodome flask
  ```

## Usage

### Server
```bash
python server.py
```

### Client
```bash
python client.py
```

### Admin Dashboard
```bash
python admin_dashboard.py
```

## Authors
CMSE456/CMPE455 Term Project Team
