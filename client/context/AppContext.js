import * as React from 'react'
import { GetUser, SaveUser } from '../helpers/Auth'
import Fetch from '../helpers/Fetch'


const AppContext = React.createContext()
function useAppContext() {
    const context = React.useContext(AppContext)
    if (!context) {
        throw new Error(`useAppContext must be used within a AppProvider`)
    }
    return context
}
function AppProvider(props) {
    const [isLoading, setIsLoading] = React.useState(false)
    const [successMsg, setSuccessMsg] = React.useState('')
    const [errorMsg, setErrorMsg] = React.useState('')
    const [user, setUser] = React.useState({})

    const hideAlerts = () => {
        setSuccessMsg('')
        setErrorMsg('')
    }

    React.useEffect(() => {
        var u = GetUser()
        setUser(u)
    }, [])

    React.useEffect(() => {
        setTimeout(hideAlerts, 2000)
    }, [successMsg, errorMsg])

    const FetchApi = async (path, method, body,  hasLoader, secure) => {
        if (hasLoader) setIsLoading(true);
        try {
            var res = await Fetch(path, method, body, secure);
        } catch (err) {
            setErrorMsg(err)
        }
        setIsLoading(false);
        return res;
    }
    const value = {
        isLoading,
        setIsLoading,
        FetchApi,
        successMsg,
        errorMsg,
        setSuccessMsg,
        setErrorMsg,
        user,
        setUser
    };
    return <AppContext.Provider value={value} {...props} />
}
export { AppProvider, useAppContext }