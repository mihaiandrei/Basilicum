import * as React from 'react';
import ParameterItem from './ParameterItem';
import IParameterModel from './ParameterModel';

interface IProps {
    parameters: IParameterModel[];
    onSelectionChanged: (parameter: IParameterModel) => void;
}

interface IState {
    parameters: IParameterModel[];
    selectedParameter?: string;
}

class ParameterRepeter extends React.Component<IProps, IState>{
    constructor(props: IProps) {
        super(props);
        this.state = { parameters: [] };
    }

    public handleLIClick = (parameter: IParameterModel) => {
        this.setState({
            selectedParameter: parameter.name
        });
    }

    public render() {
        const listItems = this.props.parameters.map((item: IParameterModel) => {
            return (<ParameterItem parameter={item} onParameterClick={this.handleLIClick}
                key={item.id} />
            );
        });

        return (
            <div className="container">
                <div>{this.state.selectedParameter}</div>
                <div className="list-group">
                    {listItems}
                </div>
            </div>
        );
    }
}

export default ParameterRepeter;