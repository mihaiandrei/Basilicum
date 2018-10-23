import * as React from 'react';

interface IProps{
    Name: string;
}

class Parameter extends React.Component<IProps>{
    public render() {
        return (
          <div>
            <p>{this.props.Name}</p>
          </div>
        );
      }
}

export default Parameter;