import React from 'react';
import TextField from '@material-ui/core/TextField';
import Autocomplete from '@material-ui/core/Autocomplete';
import { makeStyles } from '@material-ui/core/styles';
import { useRouter } from 'next/router';

const init = [
    { name: "The Shawshank Redemption", pk: 1994 },
    { name: "The Godfather", pk: 1972 },
    { name: "The Godfather: Part II", pk: 1974 },
    { name: "The Dark Knight", pk: 2008 }
];

const useStyles = makeStyles((theme) => ({
    input: {
        margin: theme.spacing(1),
    }
}));

export default function TagSelect() {
    const [value, setValue] = React.useState(null);
    const router = useRouter()
    const [inputValue, setInputValue] = React.useState('');
    const classes = useStyles();

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
                options={init}
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