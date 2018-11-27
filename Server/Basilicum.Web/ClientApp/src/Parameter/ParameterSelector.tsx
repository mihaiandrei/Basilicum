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
        if (!this.state.parameters.some(e => e.id === parameter.id)) {
            this.setState({ parameters: this.state.parameters.concat(parameter) });
        }
    }

    public removeParameter = (parameter: IParameterModel) => {
        if (this.state.parameters.some(e => e.id === parameter.id)) {
            const index = this.state.parameters.indexOf(parameter);
            this.state.parameters.splice(index, 1);
            this.setState({ parameters: this.state.parameters});
        }
    }


    public render() {
        return (
            <div>
                <div>SelectedParameters</div>
                <SelectedParameters parameters={this.state.parameters} onRemoveParameter={this.removeParameter} />
                <ParameterSearch onParameterAdded={this.addParameter} />
            </div>
        );
    }
}
export default ParameterSelector;