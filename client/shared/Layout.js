import * as React from 'react';
import CssBaseline from '@material-ui/core/CssBaseline';
import Container from '@material-ui/core/Container';
import Header from './Header';
import Footer from './Footer';
import { useAppContext } from '../context/AppContext';
import { ErrorAlert, SuccessAlert } from '../components/Alert';


const sections = [
    { title: 'Technology', url: '#' },
    { title: 'Design', url: '#' },
    { title: 'Culture', url: '#' },
    { title: 'Business', url: '#' },
    { title: 'Politics', url: '#' },
    { title: 'Opinion', url: '#' },
    { title: 'Science', url: '#' },
    { title: 'Health', url: '#' },
    { title: 'Style', url: '#' },
    { title: 'Travel', url: '#' },
];

export default function Layout({ children }) {
    const { successMsg, errorMsg } = useAppContext();

    return (
        <React.Fragment>
            <SuccessAlert msg={successMsg} />
            <ErrorAlert msg={errorMsg} />
            <CssBaseline />
            <Container maxWidth="lg">
                <Header title="Skill share" sections={sections} />
                {children}
            </Container>
            <Footer title="Footer" description="Something here to give the footer a purpose!" />
        </React.Fragment>
    );
}