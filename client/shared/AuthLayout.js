import * as React from 'react';
import { ErrorAlert, SuccessAlert } from '../components/Alert';
import { useAppContext } from '../context/AppContext';
export default function AuthLayout({ children }) {
    const { successMsg, errorMsg } = useAppContext();

    return (
        <React.Fragment>
            <ErrorAlert msg={errorMsg} />
            <SuccessAlert msg={successMsg} />
                {children}
        </React.Fragment>
        );
}