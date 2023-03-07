import React from "react";
import { useRouterContext, TitleProps } from "@pankod/refine-core";
import { Button } from "@pankod/refine-mui";
import {logo} from "../../../assets/imports";

export const Title: React.FC<TitleProps> = ({ collapsed }) => {
  const { Link } = useRouterContext();

  return (
    <Button fullWidth variant="text" disableRipple>
      <Link to="/">
        {collapsed ? (
          <img src={logo} alt="House finder" width="28px" />
        ) : (
          <img src={logo} alt="House finder" width="54px" style={{marginTop:'20px'}}/>
        )}
      </Link>
    </Button>
  );
};
