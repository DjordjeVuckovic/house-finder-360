import React, {ReactNode, useEffect, useRef, useState} from "react";
import './swiper-slider.scss'
import {MdNavigateBefore, MdOutlineNavigateNext} from "react-icons/md";
import {ButtonWithIcon} from "../buttons";

interface SwiperProps {
    children: ReactNode;
    fetchMore: () => void;
    hasMore: boolean;
}
export const SwiperSlider = ({ children, fetchMore, hasMore }: SwiperProps) => {
    const [isDragging, setIsDragging] = useState(false);
    const [startX, setStartX] = useState(0);
    const [scrollLeft, setScrollLeft] = useState(0);
    const containerRef = useRef<HTMLDivElement | null>(null);
    useEffect(() => {
        const handleScroll = () => {
            const container = containerRef.current;
            if (container) {
                const { scrollLeft, scrollWidth, clientWidth } = container;
                if (hasMore && scrollLeft >= scrollWidth - clientWidth - 300) {
                    fetchMore();
                }
            }
        };

        const container = containerRef.current;
        container?.addEventListener('scroll', handleScroll);
        return () => {
            container?.removeEventListener('scroll', handleScroll);
        };
    }, [hasMore, fetchMore]);
    const startDragging = (e: React.MouseEvent) => {
        setIsDragging(true);
        setStartX(e.pageX - (containerRef.current?.offsetLeft || 0));
        setScrollLeft(containerRef.current?.scrollLeft || 0);
    };
    const whileDragging = (e: React.MouseEvent) => {
        if (!isDragging) return;
        e.preventDefault();
        const x = e.pageX - (containerRef.current?.offsetLeft || 0);
        const walk = x - startX;
        if (containerRef.current) {
            containerRef.current.scrollLeft = scrollLeft - walk;
        }
    };

    const stopDragging = () => {
        setIsDragging(false);
    };

    return (
        <>
            <div className={'flex-end g-5'}
                 data-aos="fade-down"
                 data-aos-duration="3000">
                <ButtonWithIcon bgColor={'linear-gradient(97.05deg, #4066ff 3.76%, #2949c6 100%)'}
                                color={'#f5f8f2'}
                                icon={MdNavigateBefore}
                                width={'fit-content'}
                                onClick={() =>
                                    containerRef.current?.scrollBy({ left: -500, behavior: 'smooth' })
                                }>
                    {''}
                </ButtonWithIcon>
                <ButtonWithIcon bgColor={'linear-gradient(97.05deg, #4066ff 3.76%, #2949c6 100%)'}
                                color={'#f5f8f2'}
                                icon={MdOutlineNavigateNext}
                                width={'fit-content'}
                                iconFirst={false}
                                onClick={() =>
                                    containerRef.current?.scrollBy({ left: 500, behavior: 'smooth' })
                                }>
                    {''}
                </ButtonWithIcon>
            </div>
            <div
                className="swiper-container-hf"
                ref={containerRef}
                onMouseDown={startDragging}
                onMouseLeave={stopDragging}
                onMouseUp={stopDragging}
                onMouseMove={whileDragging}
                data-aos="fade-right"
                data-aos-duration="3000"
            >
                {children}
            </div>
        </>
    );
};
