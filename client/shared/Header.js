import React from 'react';
import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/core/styles';
import Toolbar from '@material-ui/core/Toolbar';
import Button from '@material-ui/core/Button';
import IconButton from '@material-ui/core/IconButton';
import SearchIcon from '@material-ui/icons/Search';
import Typography from '@material-ui/core/Typography';
import Link from '@material-ui/core/Link';
import { useAppContext } from '../context/AppContext';
import { AccountPopover } from '../components/Popover';
import BorderColorIcon from '@material-ui/icons/BorderColor';
import TagSearch from '../components/forms/TagSearch';
import TagSelect from '../components/forms/TagSelect'; 

const useStyles = makeStyles((theme) => ({
    toolbar: {
        borderBottom: `1px solid ${theme.palette.divider}`,
        justifyContent: 'space-between',
    },
    toolbarTitle: {
        flex: 1,
    },
    toolbarSecondary: {
        justifyContent: 'space-between',
        overflowX: 'auto',
    },
    toolbarLink: {
        padding: theme.spacing(1),
        flexShrink: 0,
    },
    btn: {
        marginRight: theme.spacing(1)
    }
}));

export default function Header(props) {
    const classes = useStyles();
    const { user } = useAppContext();
    const { sections, title } = props;
   
  return (
    <React.Fragment>
      <Toolbar className={classes.toolbar}>
           <Link
                  href="/">
            <Typography
                component="h2"
                variant="h5"
                color="inherit"
                align="left"
                noWrap
            >
                {title}
            </Typography>
            </Link>
            {/*  <IconButton>
                <SearchIcon />
              </IconButton>*/}
              <div style={{ display: 'flex' }}>
              {!user ?
                <React.Fragment>
                    <Link href="auth/login">
                    <Button variant="outlined" size="small" className={classes.btn}>
                        Sign in
                    </Button>
                    </Link>
                    <Link href="auth/signup">
                    <Button variant="outlined" size="small">
                        Sign up
                    </Button>
                    </Link>
                          
                </React.Fragment> 
                  :
                  <React.Fragment>
                      <AccountPopover user={user}/>
                      <Button >
                          <BorderColorIcon color="#ba000d" />
                    </Button>
                </React.Fragment>
              }
             </div>
          </Toolbar>
      <Toolbar component="nav" variant="dense" className={classes.toolbarSecondary}>
        {sections.map((section) => (
          <Link
            color="inherit"
            noWrap
            key={section.title}
            variant="body2"
            href={section.url}
            className={classes.toolbarLink}
          >
            {section.title}
          </Link>
        ))}
              {
                  <TagSelect />
              }
          </Toolbar>
    </React.Fragment>
  );
}

Header.propTypes = {
  sections: PropTypes.array,
  title: PropTypes.string,
};