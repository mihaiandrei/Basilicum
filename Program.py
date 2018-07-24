from CreateMesurementCommand import CreateMesurementCommand
import time
import json
import datetime
import requests

print("I'm working...")
def job():
    response = requests.get("http://localhost:1200/api/mesurement/list")
    json_data = response.json()
    command = CreateMesurementCommand(2,datetime.datetime.now(),1)
    jsonCommand=json.dumps(command.__dict__)
    print(jsonCommand)
    headers = {'Content-type': 'application/json', 'Accept': 'text/plain'}
    postResponse = requests.post("http://localhost:1200/api/mesurement",jsonCommand,headers = headers)
    print(postResponse.status_code)
    print(json_data)
    

while True:
    job()
    time.sleep(6)

print("exit")