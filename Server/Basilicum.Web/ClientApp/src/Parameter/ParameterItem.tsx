import * as React from 'react';
import IParameterModel from './ParameterModel';

interface IProps {
    parameter: IParameterModel;
    onParameterClick: (parameter: IParameterModel) => void;
}

interface IState {
    parameter: IParameterModel;
}


class ParameterItem extends React.Component<IProps, IState>{
    constructor(props: IProps) {
        super(props);
        this.state = { parameter: props.parameter };
    }

    public render() {
                return (
                <div key={this.state.parameter.id} onClick={this.handleClick}>{this.state.parameter.name}</div>
        );
    }

    private handleClick = (e: React.FormEvent<HTMLDivElement>) => {
        this.props.onParameterClick(this.state.parameter);
     }
}

export default ParameterItem;