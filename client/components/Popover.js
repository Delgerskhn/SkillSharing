import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Popover from '@material-ui/core/Popover';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import Link from 'next/link';
import { useAppContext } from '../context/AppContext';
import ExitToAppIcon from '@material-ui/icons/ExitToApp';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import DashboardIcon from '@material-ui/icons/Dashboard';
import BorderColorIcon from '@material-ui/icons/BorderColor';

const useStyles = makeStyles((theme) => ({
  typography: {
    padding: theme.spacing(2),
  },
}));

function AccountPopover() {
    const classes = useStyles();
    const [anchorEl, setAnchorEl] = React.useState(null);
    const { user, LogOut } = useAppContext();

    const handleClick = (event) => {
        setAnchorEl(event.currentTarget);
    };
   
    const handleClose = () => {
        setAnchorEl(null);
    };

    const open = Boolean(anchorEl);
    const id = open ? 'simple-popover' : undefined;

    return (
        <div>
            <Button area-describedby={id} onClick={handleClick}>
                <Typography
                    component="h6"
                    color="inherit"
                    align="left"
                    noWrap
                >
                    {user.email}
                </Typography>
            </Button>
            <Popover
                id={id}
                open={open}
                anchorEl={anchorEl}
                onClose={handleClose}
                anchorOrigin={{
                    vertical: 'bottom',
                    horizontal: 'center',
                }}
                transformOrigin={{
                    vertical: 'top',
                    horizontal: 'center',
                }}
            >
                <List>
                    <ListItemLink href="/account/dashboard" button>
                        <ListItemIcon>
                            <DashboardIcon />
                        </ListItemIcon>
                        <ListItemText primary="Dashboard" />
                    </ListItemLink>
                    <ListItemLink href="/editor" button>
                        <ListItemIcon>
                            <BorderColorIcon color="#ba000d" />
                        </ListItemIcon>
                        <ListItemText primary="Write" />
                    </ListItemLink>
                    <ListItem button onClick={ LogOut }>
                        <ListItemIcon>
                            <ExitToAppIcon />
                        </ListItemIcon>
                        <ListItemText primary="Sign out" />
                    </ListItem>
                </List>
            </Popover>
        </div>
    );
}
function ListItemLink(props) {
    return <ListItem button component="a" {...props} />;
}
export { AccountPopover }