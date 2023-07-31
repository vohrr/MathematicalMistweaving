import { styled } from "@mui/material/styles";
import Paper from "@mui/material/Paper";

export const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: '#3E3E42',
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: 'center',
    margin: "15px 5px 5px 5px",
    color: "white",
}));

export const LayoutItem = styled(Paper)(({ theme }) => ({
    backgroundColor: '#282c34',
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: 'center',
    color: "white",
    width: "auto",
    margin: "5px 5px 5px 5px"
}));