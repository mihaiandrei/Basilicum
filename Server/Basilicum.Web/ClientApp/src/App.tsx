import axios from 'axios';
import * as React from 'react';
import IParameterModel from './Parameter/ParameterModel';
import IParameterChartData from './Chart/ParameterChartData';
import ParameterChart from './Chart/ParameterChart';
import IMeasurementModel from './Measurement/MeasurementModel';
import IDateTimeValueChartItem from './Chart/DateTimeValueChartItem';

import './App.css';

import logo from './logo.svg';
import ParameterSelector from './Parameter/ParameterSelector';

interface IState {
  chartData: IParameterChartData[];
}

class App extends React.Component<{}, IState> {
  constructor() {
    super({});
    this.state = { chartData: [] };
  }

  public render() {
    return (
      <div className="App">
        <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
        </header>
        <ParameterSelector onSelectedParametersChanged={this.OnSelectedParameterChanged}
                            onParameterRemoved={this.OnParameterRemoved} />
        <ParameterChart chartData={this.state.chartData} />
      </div>
    );
  }

  private OnSelectedParameterChanged = (parameters: IParameterModel[]) => {
    parameters.forEach((parameter) => {
      this.loadMeasurement(parameter.id);
    })
  }
  
  private OnParameterRemoved = (parameter: IParameterModel) => {
    this.setState((previousState) => ({
      chartData: previousState.chartData.filter(param => param.id !== parameter.id)
    }));
  }

  private loadMeasurement = async (parameterId: number) => {
    const configurationResult = await axios.get(`/config`);
    const apiBaseAddress = configurationResult.data[`apiBaseAddress`];
    const mesurementsResult =  await axios.get(apiBaseAddress + `/api/mesurement/list?ParameterId=${parameterId}&StartDate=1%2F1%2F2019&EndDate=12%2F12%2F2019`);
    const chartItems = mesurementsResult.data.map((item: IMeasurementModel) => ({ x: new Date(item.date), y: item.value } as IDateTimeValueChartItem));
    this.setState((previousState) => ({
      chartData: previousState.chartData.concat({ id: parameterId, data: chartItems })
    }));
  }
}

export default App;
