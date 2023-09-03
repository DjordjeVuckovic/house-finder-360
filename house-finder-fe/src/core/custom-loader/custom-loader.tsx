import './custom-loader.scss'
export const CustomLoader = () => {
    return (
        <div className={'loader-container-hf'}>
            <div className="loader-hf">
                <span></span>
            </div>
            <svg>
                <defs>
                    <filter id="goo">
                        <feGaussianBlur in="SourceGraphic" stdDeviation="11" result="blur"></feGaussianBlur>
                        <feColorMatrix in="blur" mode="matrix" values="1 0 0 0 0  0 1 0 0 0  0 0 1 0 0  0 0 0 19 -9" result="goo" />
                    </filter>
                </defs>
            </svg>
        </div>
    );
};
