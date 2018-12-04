import axios from 'axios';
import { VictoryAxis, VictoryChart, VictoryLine, VictoryScatter } from "victory";
import * as React from 'react';
import IMeasurementModel from '../Measurement/MeasurementModel';
import IDateTimeValueChartItem from './DateTimeValueChartItem'

interface IState {
    chartDataItems: IDateTimeValueChartItem[];
}
interface IProps {
    parameterId: number | null
}

class ParameterChart extends React.Component<IProps, IState>{
    constructor(props: IProps) {
        super(props);
        this.state = { chartDataItems: [] };
        this.loadMeasurement();
    }

    public loadMeasurement = () => {

        axios.get(`http://localhost:1200/api/mesurement/list?ParameterId=3&StartDate=1%2F1%2F2018&EndDate=12%2F12%2F2018`)
            .then(res => {

                const chartItems = res.data.map((item: IMeasurementModel) => ({ x: new Date(item.date), y: item.value } as IDateTimeValueChartItem));
                this.setState({
                    chartDataItems: chartItems
                });
            })
    }

    public render() {
        return (
            <div>
                <VictoryChart width={600} height={470} scale={{ x: "time" }}>
                    <VictoryAxis tickFormat={this.tickFormatYear}
                        tickCount={3}
                    />
                    <VictoryAxis dependentAxis={true} />
                    <VictoryLine data={this.state.chartDataItems}
                                interpolation="linear" />
                    <VictoryScatter style={{ data: { fill: 'red' } }}
                                    size={2}
                                    data={this.state.chartDataItems}
                    />
                </VictoryChart>
            </div>
        );
    }
    private tickFormatYear = (x: Date) =>x.toLocaleString();
}

export default ParameterChart;