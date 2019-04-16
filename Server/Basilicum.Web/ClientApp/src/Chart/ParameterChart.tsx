import { VictoryAxis, VictoryChart, VictoryLine, VictoryScatter, VictoryTooltip } from "victory";
import * as React from 'react';
import IParameterChartData from './ParameterChartData';
import DatePicker from 'react-datepicker'
import "react-datepicker/dist/react-datepicker.css";

interface IProps {
    chartData: IParameterChartData[]
}

interface IState {
    startDate: Date;
}

class ParameterChart extends React.Component<IProps, IState>{
    constructor(props: IProps) {
        super(props);
        this.state = { startDate: new Date() };
    }

    public render() {
        const lines = this.props.chartData.map((item) => {
            return (
                <VictoryLine data={item.data} key={item.id} />
            );
        });

        const points = this.props.chartData.map((item) => {
            return (
                <VictoryScatter
                    style={{ data: { fill: 'green' } }}
                    size={2}
                    data={item.data}
                    key={item.id}
                    labels={(d) => d.y}
                    labelComponent={<VictoryTooltip />}
                />
            );
        });

        return (
            <div>
                <div>
                    <VictoryChart width={600} height={470} scale={{ x: "time" }}>
                        <VictoryAxis
                            tickFormat={this.tickFormatYear}
                            tickCount={2}
                        />
                        {lines}
                        {points}
                        <VictoryAxis dependentAxis={true} />
                    </VictoryChart>
                </div>
                <div className="container">
                    <div className="react-datepicker-wrapper">
                        <DatePicker
                            selected={this.state.startDate}
                            onChange={this.handleStartDateChange}
                            showTimeSelect={true}
                            timeFormat="HH:mm"
                            timeIntervals={15}
                            timeCaption="time"
                            placeholderText="Start date" />
                    </div>
                </div>
            </div>
        );
    }
    private tickFormatYear = (x: Date) => x.toLocaleString();
    private handleStartDateChange = (date: Date) => { this.setState({ startDate: date }) };

}

export default ParameterChart;