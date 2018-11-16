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
       this.setState({ parameters:[parameter] });
        }

    public render() {
        return (
            <div>
                <div>SelectedParameters</div>
                <ParameterSearch onParameterAdded={this.addParameter} />
                <SelectedParameters parameters={this.state.parameters} />
                
            </div>
        );
    }
}
export default ParameterSelector;