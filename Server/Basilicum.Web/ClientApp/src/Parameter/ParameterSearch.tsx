import axios from 'axios';
import * as React from 'react';
import IParameterModel from './ParameterModel';
import ParameterRepeter from './ParameterRepeter';

interface IProps {
    onParameterAdded: (parameter: IParameterModel) => void;
}

interface IState {
    searchText: string;
    parameters: IParameterModel[];
}

class ParameterSearch extends React.Component<IProps, IState>{
    constructor(props: IProps) {
        super(props);
        this.state = { searchText: "", parameters: [] };
    }

    public handleTextChange = async (e: React.FormEvent<HTMLInputElement>) => {
        const actualSearchText = e.currentTarget.value;
        const configResult = await axios.get(`/config`)
        const apiBaseAddress = configResult.data[`apiBaseAddress`];
        const parameterResult = await axios.get(apiBaseAddress + `/api/parameter/list?SearchString=${actualSearchText}`);
        this.setState({
            parameters: parameterResult.data,
            searchText: actualSearchText
        });
    }

    public render() {
        return (
            <div>
                <input placeholder="Search for..." onChange={this.handleTextChange} />
                <ParameterRepeter parameters={this.state.parameters} onSelectionChanged={this.selectionChanged} />
            </div>
        );
    }
    private selectionChanged = (parameter: IParameterModel) => {
        this.props.onParameterAdded(parameter);
    }
}

export default ParameterSearch;