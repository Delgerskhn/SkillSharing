import * as React from 'react'


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

    const hideAlerts = () => {
        setSuccessMsg('')
        setErrorMsg('')
    }
   
    React.useEffect(() => {
        setTimeout(hideAlerts, 2000)
    }, [successMsg, errorMsg])

    const value = {
        isLoading,
        setIsLoading,
        successMsg,
        errorMsg,
        setSuccessMsg,
        setErrorMsg
    };
    return <AppContext.Provider value={value} {...props} />
}
export { AppProvider, useAppContext }