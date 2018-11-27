import * as React from 'react';
import IParameterModel from './ParameterModel';
import RemoveParameterItem from './RemoveParameterItem'

interface IProps {
    parameters: IParameterModel[];
    onRemoveParameter: (parameter: IParameterModel) => void;
}

interface IState {
    parameters: IParameterModel[];
}

class SelectedParameters extends React.Component<IProps, IState>{
    constructor(props: IProps) {
        super(props);
        this.state = { parameters: this.props.parameters};
    }

    public render() {
        const listItems = this.props.parameters.map((item: IParameterModel) => {
            return (<RemoveParameterItem parameter={item} onParameterClick={this.handleRemove}
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

    public handleRemove = (parameter: IParameterModel) => {
        this.props.onRemoveParameter(parameter);
    }
}
export default SelectedParameters;