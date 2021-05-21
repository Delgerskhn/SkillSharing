import React, { useEffect } from "react";
import TextField from "@material-ui/core/TextField";
import Autocomplete from "@material-ui/core/Autocomplete";
import { makeStyles } from "@material-ui/core/styles";
import { useRouter } from "next/router";
import { onEnter } from "../../helpers/keyHandlers";
import { createTag, fetchTags, getTags } from "../../api/tags";

const useStyles = makeStyles(theme => ({
    input: {
        margin: theme.spacing(1)
    }
}));

export default function TagSearch({ onSelectCallback }) {
    const [tags, setTags] = React.useState([]);
    const [selectValue, setSelectValue] = React.useState([]);
    const [inputValue, setInputValue] = React.useState("");
    const initTags = async () => {
        await fetchTags()
        setTags(getTags())
    }
    useEffect(() => {
        initTags()
    }, [])

    const addNewTag = async (e) => {
        const newTag = { name: inputValue }
        await createTag(newTag)
        onSelect(e,[...selectValue, newTag])
    }

    const onSelect = async (ev, val) => {
        setSelectValue([...val])
        onSelectCallback && onSelectCallback(val)
    }

    return (
        <div>
            <Autocomplete
                multiple
                value={ selectValue }
                id="tags-standard"
                onChange={onSelect}
                style={{ width: 300 }}
                options={tags}
                getOptionLabel={(option) => option?.name || ''}
                onKeyDown={(e) => onEnter(e, addNewTag)}
                renderInput={(params) => (
                    <TextField
                        {...params}
                        variant="standard"
                        value={inputValue}
                        onChange={(e) => setInputValue(e.target.value)}
                        label="Enter related tags"
                        placeholder="Tag name"
                    />
                )}
            />
           
        </div>
    );
}
