import React from 'react';
import TextField from '@material-ui/core/TextField';
import Autocomplete from '@material-ui/core/Autocomplete';
import { makeStyles } from '@material-ui/core/styles';
import { useRouter } from 'next/router';

const tags = ['Tag 1', 'Option 2'];


const useStyles = makeStyles((theme) => ({
    input: {
        margin: theme.spacing(1),
    }
}));

export default function SelectableSearch() {
    const [value, setValue] = React.useState('');
    const router = useRouter()
  const [inputValue, setInputValue] = React.useState('');
    const classes = useStyles();

  return (
    <div>
      <Autocomplete
        value={value}
              onChange={(event, newValue) => {
            router.push('/?tag='+newValue)
          setValue(newValue);
        }}
        inputValue={inputValue}
        onInputChange={(event, newInputValue) => {
          setInputValue(newInputValue);
        }}
        options={tags}
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
