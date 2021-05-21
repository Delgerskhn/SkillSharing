import React, { useEffect, useState } from 'react';
import TextField from '@material-ui/core/TextField';
import Autocomplete from '@material-ui/core/Autocomplete';
import { makeStyles } from '@material-ui/core/styles';
import { useRouter } from 'next/router';
import { fetchTags, getTags } from '../../api/tags';

const useStyles = makeStyles((theme) => ({
    input: {
        margin: theme.spacing(1),
    }
}));

export default function TagSelect() {
    const [value, setValue] = React.useState(null);
    const [options, setOptions] = useState([])
    const router = useRouter()
    const [inputValue, setInputValue] = React.useState('');
    const classes = useStyles();
    const initTags = async () => {
        await fetchTags()
        setOptions(getTags())
    }
    useEffect(() => {
        initTags()
    }, [])
    return (
        <div>
            <Autocomplete
                value={value}
                onChange={(event, newValue) => {
                    setValue(newValue);
                    router.push('/?tag=' + newValue.pk)
                }}
                getOptionLabel={(option) => option?.name || ''} 
                inputValue={inputValue}
                onInputChange={(event, newInputValue) => {
                    setInputValue(newInputValue);
                }}
                options={options}
                style={{ width: 250 }}
                renderInput={(params) =>
                    <TextField
                        className={classes.input}
                        variant="standard"
                        inputProps={{ 'aria-label': 'naked' }}
                        id="standard-basic" {...params}
                        placeholder="Search by tag" />}
            />
        </div>
    );
}