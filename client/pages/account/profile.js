import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import classNames from "classnames";
import { Button } from "../../components/blogs/Components";

const profilePageStyle = {
    profile: {
        textAlign: "center",
        "& img": {
            maxWidth: "160px",
            width: "100%",
            margin: "0 auto",
            transform: "translate3d(0, -50%, 0)",
        },
    },
    description: {
        margin: "1.071rem auto 0",
        maxWidth: "600px",
        color: "#999",
        textAlign: "center !important",
    },
    name: {
        marginTop: "-80px",
    },
    main: {
        background: "#FFFFFF",
        position: "relative",
        zIndex: "3",
    },
    mainRaised: {
        margin: "-60px 30px 0px",
        borderRadius: "6px",
        boxShadow:
            "0 16px 24px 2px rgba(0, 0, 0, 0.14), 0 6px 30px 5px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2)",
    },
    title: {
        display: "inline-block",
        position: "relative",
        marginTop: "30px",
        minHeight: "32px",
        textDecoration: "none",
    },
    socials: {
        marginTop: "0",
        width: "100%",
        transform: "none",
        left: "0",
        top: "0",
        height: "100%",
        lineHeight: "41px",
        fontSize: "20px",
        color: "#999",
    },
    navWrapper: {
        margin: "20px auto 50px auto",
        textAlign: "center",
    },
};
const useStyles = makeStyles(profilePageStyle);
export default function Profile() {
    const classes = useStyles();
    const imageClasses = classNames(
        classes.imgRaised,
        classes.imgRoundedCircle,
        classes.imgFluid
    );
    return (
        <div className={classes.profile}>
            <div>
                <img
                    src="/christian.jpg"
                    alt="..."
                    className={imageClasses}
                />
            </div>
            <div className={classes.name}>
                <h3 className={classes.title}>Christian Louboutin</h3>
                <h6>DESIGNER</h6>
                <Button justIcon link className={classes.margin5}>
                    <i className={"fab fa-twitter"} />
                </Button>
                <Button justIcon link className={classes.margin5}>
                    <i className={"fab fa-instagram"} />
                </Button>
                <Button justIcon link className={classes.margin5}>
                    <i className={"fab fa-facebook"} />
                </Button>
            </div>
        </div>
        );
}



