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
    public items: IParameterModel[] = [
        { name: 'Matthew' },
        { name: 'Mark' },
        { name: 'Luke' },
        { name: 'John' }
    ];

    constructor(props: IProps) {
        super(props);
        this.state = { searchText: "", parameters: [] };
    }
    public handleTextChange = (e: React.FormEvent<HTMLInputElement>) => {
        this.setState({
            parameters: this.items,
            searchText: e.currentTarget.value
        });
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