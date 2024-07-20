import './styles/Global.css';
import Home from './routes/Home';
import Brands from './routes/Brands';
import { Route, Routes } from 'react-router-dom';
import Navbar from './components/Navbar/Navbar';
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

const queryClient = new QueryClient();

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <Navbar/>
      <Routes>
        <Route path='/' element={<Home/>}/>
        <Route path='/brands' element={<Brands/>}/>
      </Routes>
    </QueryClientProvider>
  );
}

export default App;