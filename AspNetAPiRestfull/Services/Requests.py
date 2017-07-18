import requests, json

data = {"usuario":"bsnascimento","senha":"brq@0120","salvarUsuario":"true"}
data = json.dumps(data)
headers = {'content-type': 'application/x-www-form-urlencoded; charset=UTF-8'}
url = 'https://portal.brq.com/Login/Log'

try:
    response = requests.post(url = url, data = data, headers = headers)
    print(response))
except requests.ConnectionError as e:  # This is the correct syntax
    print (e)