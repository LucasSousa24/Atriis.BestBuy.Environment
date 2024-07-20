import { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';

const useNavbar = () => {
    const location = useLocation();

    const [activeNavBar, setActiveNavBar] = useState(1);

    useEffect(() => {
        setActiveFlag();
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [location]);

    const setActiveFlag = () => {
        var activePath = location.pathname;
        if (activePath === "/") {
            setActiveNavBar(1);
        } else if (activePath === "/brands"){
            setActiveNavBar(2);
        } else if(activePath === "/about") {
            setActiveNavBar(3);
        }
    }

    return {
        activeNavBar
    };
}

export default useNavbar
