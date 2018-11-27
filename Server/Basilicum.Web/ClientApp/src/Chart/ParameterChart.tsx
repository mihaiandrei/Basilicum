import axios from 'axios';
import { VictoryChart, VictoryLine } from "victory";
import * as React from 'react';
import IMeasurementModel from '../Measurement/MeasurementModel';
import IDateTimeValueChartItem from './DateTimeValueChartItem'

interface IState {
    measurements: IDateTimeValueChartItem[];
}
interface IProps {
    parameterId: number | null
}

class ParameterChart extends React.Component<IProps, IState>{
    constructor(props: IProps) {
        super(props);
        this.state = { measurements: [] };
        this.handleTextChange();
    }

    public handleTextChange = () => {

        axios.get(`http://localhost:1200/api/mesurement/list?ParameterId=3&StartDate=1%2F1%2F2018&EndDate=12%2F12%2F2018`)
            .then(res => {

                const chartItems = res.data.map((item: IMeasurementModel) => ({ x: item.date, y: item.value } as IDateTimeValueChartItem));
                this.setState({
                    measurements: chartItems
                });
            })
    }

    public render() {
        return (
            <div>
                <VictoryChart>
                    <VictoryLine
                        data={this.state.measurements}
                    />
                </VictoryChart>
            </div>
        );
    }
}

export default ParameterChart;