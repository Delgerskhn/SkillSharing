import { useRouter } from 'next/router';
import React, { useEffect } from 'react'
import Loader from '../components/Loader';
import { useAppContext } from '../context/AppContext'
import { useAuth } from '../context/auth';
import { GetUser } from '../helpers/UserStore';

const withAuth = (WrappedComponent) => {
    const Wrapper = ({ children, ...props })=> {
        const router = useRouter();
        const { user, loading } = useAuth();

        if (!loading) {
            if (user == null) router.push('auth/login')
        } else {
            return <div></div>
        }
        return (<WrappedComponent {...props} >{children}</WrappedComponent>)
    }
  
    return Wrapper
}

export { withAuth }