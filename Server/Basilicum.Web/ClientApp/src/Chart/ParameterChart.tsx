import axios from 'axios';
import { VictoryAxis, VictoryChart, VictoryLine, VictoryScatter } from "victory";
import * as React from 'react';
import IMeasurementModel from '../Measurement/MeasurementModel';
import IDateTimeValueChartItem from './DateTimeValueChartItem'
import IParameterChartData from './ParameterChartData'

interface IState {
    chartData: IParameterChartData[];
}
interface IProps {
    parameterId: number | null
}

class ParameterChart extends React.Component<IProps, IState>{
    constructor(props: IProps) {
        super(props);
        this.state = { chartData: [] };
        this.loadMeasurement(3);
        this.loadMeasurement(1015);

    }

    public loadMeasurement = (parameterId: number) => {
        axios.get(`http://localhost:1200/api/mesurement/list?ParameterId=${parameterId}&StartDate=1%2F1%2F2018&EndDate=12%2F12%2F2018`)
            .then(res => {
                const chartItems = res.data.map((item: IMeasurementModel) => ({ x: new Date(item.date), y: item.value } as IDateTimeValueChartItem));
                this.setState({
                    chartData: this.state.chartData.concat({ id: parameterId, data: chartItems })
                });
            })
    }



    public render() {
        const lines = this.state.chartData.map((item) => {
            return (
                <VictoryLine data={item.data} key={item.id} />
            );
        });


        const points = this.state.chartData.map((item) => {
            return (
                <VictoryScatter style={{ data: { fill: 'green' } }}
                    size={2}
                    data={item.data}
                    key={item.id}
                />
            );
        });


        return (
            <div>
                <VictoryChart width={600} height={470} scale={{ x: "time" }}>
                    <VictoryAxis tickFormat={this.tickFormatYear}
                        tickCount={3}
                    />
                    {lines}
                    {points}
                    <VictoryAxis dependentAxis={true} />
                </VictoryChart>
            </div>
        );
    }
    private tickFormatYear = (x: Date) => x.toLocaleString();
}

export default ParameterChart;