import { useRouter } from 'next/router';
import React, { useEffect } from 'react'
import { useAppContext } from '../context/AppContext'
import { GetUser } from '../helpers/UserStore';

const withAuth = (WrappedComponent) => {
    const Wrapper = ({ children, ...props })=> {
        const { user } = useAppContext();
        const router = useRouter();

        useEffect(() => {
            if(user===null) router.push('/auth/login')
        }, [user])

        return (<WrappedComponent {...props} >{children}</WrappedComponent>)
    }
  
    return Wrapper
}

export { withAuth }