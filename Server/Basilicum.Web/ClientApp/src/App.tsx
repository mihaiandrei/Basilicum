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
          <h1 className="App-title">Welcome to React</h1>
        </header>
        <p className="App-intro">
          To get started, edit <code>src/App.tsx</code> and save to reload.
        </p>
        <ParameterSelector onSelectedParametersChanged={this.OnSelectedParameterChanged} />
        <ParameterChart chartData={this.state.chartData} />
      </div>
    );
  }

  private OnSelectedParameterChanged = (parameters: IParameterModel[]) => {
    parameters.forEach((parameter) => {
      this.loadMeasurement(parameter.id);
    })
  }

  private loadMeasurement = (parameterId: number) => {
    axios.get(`http://localhost:1200/api/mesurement/list?ParameterId=${parameterId}&StartDate=1%2F1%2F2018&EndDate=12%2F12%2F2018`)
      .then(res => {
        const chartItems = res.data.map((item: IMeasurementModel) => ({ x: new Date(item.date), y: item.value } as IDateTimeValueChartItem));
        this.setState((previousState) => ({
          chartData: previousState.chartData.concat({ id: parameterId, data: chartItems })
        }));
      })
  }

}

export default App;
