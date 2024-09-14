import Logo from '../../assets/Logo'

const Navbar = () => {
    return (
        <div className='flex w-full bg-[#BD1A37] sm:h-[64px] h-[56px] px-4 items-center drop-shadow-md'>
            <Logo />
            <div className='flex w-full justify-end'>
                <div className='bg-blue-400 rounded-full w-8 h-8'>
                    {}
                </div>
            </div>
        </div>
    )
}

export default Navbar
