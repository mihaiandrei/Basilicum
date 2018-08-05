import RPi.GPIO as GPIO
import time, sys

FLOW_SENSOR = 23
PUMP_ENABLE = 14
PUMP_FORWARD = 15
PUMP_BACKWARDS = 18

GPIO.setmode(GPIO.BCM)
GPIO.setup(FLOW_SENSOR, GPIO.IN, pull_up_down = GPIO.PUD_UP)
GPIO.setup(PUMP_ENABLE, GPIO.OUT)
GPIO.setup(PUMP_FORWARD, GPIO.OUT)
GPIO.setup(PUMP_BACKWARDS, GPIO.OUT)

def startPump():
    GPIO.output(14, GPIO.HIGH)
    GPIO.output(15, GPIO.HIGH)
    GPIO.output(18, GPIO.LOW)

def stopPump():
    GPIO.output(14, GPIO.LOW)
    GPIO.output(15, GPIO.LOW)
    GPIO.output(18, GPIO.LOW)

def countPulse(channel):
    global count
    count = count+1
	
GPIO.add_event_detect(FLOW_SENSOR, GPIO.FALLING, callback=countPulse)
startPump()
while True:
    try:
        time.sleep(5)
        global count
        print(count*1.7)
        print(count)
    except KeyboardInterrupt:
        print '\ncaught keyboard interrupt!, bye'
		stopPump()
        GPIO.cleanup()
        sys.exit()