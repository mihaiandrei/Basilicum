class CreateMesurementCommand:
    def __init__(self,value,date,parameterId):
        self.value=value
        self.date=date.__str__()
        self.parameterId=parameterId