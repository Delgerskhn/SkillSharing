import React, { useCallback, useMemo, useState } from 'react';

import isHotkey from 'is-hotkey'
import { Editable, withReact,  Slate } from 'slate-react'
import {
    Editor,
    createEditor,
} from 'slate'
import {  Toolbar } from './Components'
import { Element } from './ElementTypes'
import { Leaf } from './LeafTypes'
import { BlockButton, MarkButton } from './ButtonTypes';

const HOTKEYS = {
    'mod+b': 'bold',
    'mod+i': 'italic',
    'mod+u': 'underline',
    'mod+`': 'code',
}


const initialValue = {
    type: "heading-one",
    children: [{ text: "" }]
}
export default function BlogEditor() {

    const editor = useMemo(() => withReact(createEditor()), [])
    const [value, setValue] = useState([initialValue])
    const renderElement = useCallback(props => <Element {...props} />, [])
    const renderLeaf = useCallback(props => <Leaf {...props} />, [])

    return (
        <Slate editor={editor} value={value} onChange={value => setValue(value)}>
            {false ? 
                true
                : null}
            <Toolbar>
                <MarkButton format="bold" icon="format_bold" />
                <MarkButton format="italic" icon="format_italic" />
                <MarkButton format="underline" icon="format_underlined" />
                <MarkButton format="code" icon="code" />
                <BlockButton format="heading-one" icon="looks_one" />
                <BlockButton format="heading-two" icon="looks_two" />
                <BlockButton format="block-quote" icon="format_quote" />
                <BlockButton format="numbered-list" icon="format_list_numbered" />
                <BlockButton format="bulleted-list" icon="format_list_bulleted" />
            </Toolbar>
            <Editable
                renderElement={renderElement}
                renderLeaf={renderLeaf}
                placeholder="Title..."
                spellCheck
                autoFocus
                onKeyDown={event => {
                    for (const hotkey in HOTKEYS) {
                        if (isHotkey(hotkey, event)) {
                            event.preventDefault()
                            const mark = HOTKEYS[hotkey]
                            toggleMark(editor, mark)
                        }
                    }
                }}
            />
        </Slate>
    );
}


const toggleMark = (editor, format) => {
    const isActive = isMarkActive(editor, format)

    if (isActive) {
        Editor.removeMark(editor, format)
    } else {
        Editor.addMark(editor, format, true)
    }
}
