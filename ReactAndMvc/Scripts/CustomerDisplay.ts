import React from 'react';
import ReactDOM from 'react-dom';

export class CustomerDTO {
    public LastName: string;
    public FirstName: string;

}

function DisplayCustomer(cDTO: CustomerDTO) {
    ReactDOM.render(
        <CustomerForm FirstName={cDTO.FirstName} LastName={cDTO.LastName}/>,
        document.getElementById('divDisplayCustomer'));
}

interface propsCustomer {
  FirstName: string;
  LastName: string;
}

class CustomerForm extends React.Component<propsCustomer, {}> 
{
    render() {
        return (
            <p>
                First Name: {this.props.FirstName}
                <br/>
                Last Name:{this.props.LastName}
                <br/>
                ...more properties...
            </p>
        )
    }
}