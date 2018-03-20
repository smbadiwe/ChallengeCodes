import React from 'react';
import ReactDOM from 'react-dom';

class CustomerDTO {
    public LastName: string;
    public FirstName: string;
}

class CustomerForm extends React.Component {
    render() {
        return (
            <p>
                First Name: {this.props.FirstName}
                <br/>
                Last Name:{this.props.LastName}
                <br/>
                ...more properties...
            </p>
        );
    }
}
                
function DisplayCustomer(cDTO: CustomerDTO) {
    ReactDOM.render(
        <CustomerForm FirstName={cDTO.FirstName} LastName={cDTO.LastName} />,
        document.getElementById('divDisplayCustomer'));
}
