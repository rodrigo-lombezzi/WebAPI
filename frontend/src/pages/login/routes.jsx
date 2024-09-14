import { BrowserRouter as Router, Route, Routes, Navigate } from "react-router-dom";
import Login from "./Pages/login";

const AppRoutes = () => {
    return(
        <Router>
            <Routes>
                <Route path="/" element ={<Login />} />
                <Route path="/Inicio" element ={<Home />} />
            </Routes>
        </Router>
    )
}
export default AppRoutes