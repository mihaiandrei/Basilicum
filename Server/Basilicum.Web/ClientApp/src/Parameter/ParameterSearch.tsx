import axios from 'axios';
import * as React from 'react';
import IParameterModel from './ParameterModel';
import ParameterRepeter from './ParameterRepeter';

interface IProps {
    parameter: string;
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
    public handleTextChange = (e: React.FormEvent<HTMLInputElement>) => {
        const actualSearchText = e.currentTarget.value;
        axios.get(`http://localhost:1200/api/parameter/list`)
      .then(res => {
        this.setState({
            parameters: res.data,
            searchText: actualSearchText
        });
      })

    }

    public render() {
        return (
            <div>
                <div>{this.state.searchText}</div>

                <input placeholder="Search for..." onChange={this.handleTextChange} />
                <ParameterRepeter parameters={this.state.parameters} />
            </div>
        );
    }
}

export default ParameterSearch;