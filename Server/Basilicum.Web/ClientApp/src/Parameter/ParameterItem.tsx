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

    public handleLIClick = (e: React.FormEvent<HTMLLIElement>) => {
        this.setState({
        });
    }

    public render() {
                return (
                <div key={this.state.parameter.id}>{this.state.parameter.name}</div>
        );
    }
}

export default ParameterItem;