import * as React from 'react';
import { Glyphicon } from 'react-bootstrap';
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
                <a href="#" className="list-group-item" onClick={this.handleClick} >
                 <Glyphicon glyph="plus align-left" /> 
                  <div>{this.state.parameter.name}</div>  
                </a>
        );
    }

    private handleClick = (e: React.FormEvent<HTMLAnchorElement>) => {
        this.props.onParameterClick(this.state.parameter);
     }
}

export default ParameterItem;