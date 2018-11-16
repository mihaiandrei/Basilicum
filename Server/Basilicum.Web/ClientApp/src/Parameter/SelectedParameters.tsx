import * as React from 'react';
import IParameterModel from './ParameterModel';

interface IProps {
    parameters: IParameterModel[];
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
            return (<div key={item.id} >{item.name}</div>
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
export default SelectedParameters;