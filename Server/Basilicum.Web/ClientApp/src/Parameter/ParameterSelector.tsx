import * as React from 'react';
import IParameterModel from './ParameterModel';
import ParameterSearch from './ParameterSearch';
import SelectedParameters from './SelectedParameters';

interface IState {
    parameters: IParameterModel[];
}

class ParameterSelector extends React.Component<{}, IState>{
    constructor() {
        super({});
        this.state = { parameters: [] };
    }

    public addParameter = (parameter: IParameterModel) => {
         if(!this.state.parameters.some(e => e.id === parameter.id)){
            this.setState({ parameters:this.state.parameters.concat(parameter)});
        }
    }

    public render() {
        return (
            <div>
                <div>SelectedParameters</div>
                <SelectedParameters parameters={this.state.parameters} />
                <ParameterSearch onParameterAdded={this.addParameter} />
            </div>
        );
    }
}
export default ParameterSelector;