import { VictoryAxis, VictoryChart, VictoryLine, VictoryScatter, VictoryTooltip } from "victory";
import * as React from 'react';
import IParameterChartData from './ParameterChartData';

interface IProps {
    chartData: IParameterChartData[]
}

class ParameterChart extends React.Component<IProps>{
    constructor(props: IProps) {
        super(props);
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
                    labelComponent={<VictoryTooltip/>}
                />
            );
        });

        return (
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
        );
    }
    private tickFormatYear = (x: Date) => x.toLocaleString();
}

export default ParameterChart;