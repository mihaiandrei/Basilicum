import * as React from 'react';
import AddParameterItem from './AddParameterItem';
import IParameterModel from './ParameterModel';

interface IProps {
    parameters: IParameterModel[];
    onSelectionChanged: (parameter: IParameterModel) => void;
}

interface IState {
    parameters: IParameterModel[];
}

class ParameterRepeter extends React.Component<IProps, IState>{
    constructor(props: IProps) {
        super(props);
        this.state = { parameters: [] };
    }

    public handleLIClick = (parameter: IParameterModel) => {
        this.props.onSelectionChanged(parameter);
    }

    public render() {
        const listItems = this.props.parameters.map((item: IParameterModel) => {
            return (<AddParameterItem parameter={item} onParameterClick={this.handleLIClick}
                key={item.id} />
            );
        });

        return (
            <div className="container">
                <div className="list-group">
                    {listItems}
                </div>
            </div>
        );
    }
}

export default ParameterRepeter;