import React from "react";
import TextField from "@material-ui/core/TextField";
import Autocomplete from "@material-ui/core/Autocomplete";
import { makeStyles } from "@material-ui/core/styles";
import { useRouter } from "next/router";
import { onEnter } from "../../helpers/keyHandlers";

const init = [
    { name: "The Shawshank Redemption", pk: 1994 },
    { name: "The Godfather", pk: 1972 },
    { name: "The Godfather: Part II", pk: 1974 },
    { name: "The Dark Knight", pk: 2008 }
];

const useStyles = makeStyles(theme => ({
    input: {
        margin: theme.spacing(1)
    }
}));

export default function TagSearch() {
    const [tags, setTags] = React.useState(init);
    const router = useRouter();
    const [inputValue, setInputValue] = React.useState("");
    const classes = useStyles();
    const addNewTag = () => {
        const newTag = { name: inputValue }
        setTags([...tags, newTag])
    }
    return (
        <div>
            <Autocomplete
                multiple
                id="tags-standard"
                style={{ width: 300 }}
                options={tags}
                getOptionLabel={(option) => option.name}
                defaultValue={[tags[0]]}
                onKeyDown={(e) => onEnter(e, addNewTag)}
                renderInput={(params) => (
                    <TextField
                        {...params}
                        variant="standard"
                        value={inputValue}
                        onChange={(e) => setInputValue(e.target.value)}
                        label="Multiple values"
                        placeholder="Tag name"
                    />
                )}
            />
           
        </div>
    );
}
