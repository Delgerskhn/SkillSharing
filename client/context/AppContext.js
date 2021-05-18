import * as React from 'react'
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
    const FetchApi = async (path, method, body, secure) => {
        setIsLoading(true);
        var res = await Fetch(path, method, body, secure);
        setIsLoading(false);
        return res;
    }
    const value = { isLoading, setIsLoading, FetchApi };
    return <AppContext.Provider value={value} {...props} />
}
export { AppProvider, useAppContext }