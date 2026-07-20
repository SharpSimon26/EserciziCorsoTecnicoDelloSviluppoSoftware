--
-- PostgreSQL database dump
--

\restrict yAhPIyf1Nqb5Bmdhnyeje21EkJbZ1gZ7dLNx70dNTwva1kic3sU83dpn2tykxvD

-- Dumped from database version 18.3 (Debian 18.3-1.pgdg13+1)
-- Dumped by pg_dump version 18.3

-- Started on 2026-05-08 12:23:48 UTC

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 7 (class 2615 OID 16390)
-- Name: json_placeholder; Type: SCHEMA; Schema: -; Owner: docker
--

CREATE SCHEMA json_placeholder;


ALTER SCHEMA json_placeholder OWNER TO docker;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 224 (class 1259 OID 16408)
-- Name: posts; Type: TABLE; Schema: json_placeholder; Owner: docker
--

CREATE TABLE json_placeholder.posts (
    id integer NOT NULL,
    utente_id integer NOT NULL,
    titolo character varying(255) NOT NULL,
    contenuto text,
    data_creazione timestamp with time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


ALTER TABLE json_placeholder.posts OWNER TO docker;

--
-- TOC entry 223 (class 1259 OID 16407)
-- Name: posts_id_seq; Type: SEQUENCE; Schema: json_placeholder; Owner: docker
--

CREATE SEQUENCE json_placeholder.posts_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE json_placeholder.posts_id_seq OWNER TO docker;

--
-- TOC entry 3464 (class 0 OID 0)
-- Dependencies: 223
-- Name: posts_id_seq; Type: SEQUENCE OWNED BY; Schema: json_placeholder; Owner: docker
--

ALTER SEQUENCE json_placeholder.posts_id_seq OWNED BY json_placeholder.posts.id;


--
-- TOC entry 222 (class 1259 OID 16392)
-- Name: utenti; Type: TABLE; Schema: json_placeholder; Owner: docker
--

CREATE TABLE json_placeholder.utenti (
    id integer NOT NULL,
    nome character varying(255) NOT NULL,
    email character varying(255) NOT NULL,
    data_creazione timestamp with time zone DEFAULT CURRENT_TIMESTAMP NOT NULL
);


ALTER TABLE json_placeholder.utenti OWNER TO docker;

--
-- TOC entry 221 (class 1259 OID 16391)
-- Name: utenti_id_seq; Type: SEQUENCE; Schema: json_placeholder; Owner: docker
--

CREATE SEQUENCE json_placeholder.utenti_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE json_placeholder.utenti_id_seq OWNER TO docker;

--
-- TOC entry 3465 (class 0 OID 0)
-- Dependencies: 221
-- Name: utenti_id_seq; Type: SEQUENCE OWNED BY; Schema: json_placeholder; Owner: docker
--

ALTER SEQUENCE json_placeholder.utenti_id_seq OWNED BY json_placeholder.utenti.id;


--
-- TOC entry 3300 (class 2604 OID 16411)
-- Name: posts id; Type: DEFAULT; Schema: json_placeholder; Owner: docker
--

ALTER TABLE ONLY json_placeholder.posts ALTER COLUMN id SET DEFAULT nextval('json_placeholder.posts_id_seq'::regclass);


--
-- TOC entry 3298 (class 2604 OID 16395)
-- Name: utenti id; Type: DEFAULT; Schema: json_placeholder; Owner: docker
--

ALTER TABLE ONLY json_placeholder.utenti ALTER COLUMN id SET DEFAULT nextval('json_placeholder.utenti_id_seq'::regclass);


--
-- TOC entry 3458 (class 0 OID 16408)
-- Dependencies: 224
-- Data for Name: posts; Type: TABLE DATA; Schema: json_placeholder; Owner: docker
--



--
-- TOC entry 3456 (class 0 OID 16392)
-- Dependencies: 222
-- Data for Name: utenti; Type: TABLE DATA; Schema: json_placeholder; Owner: docker
--

INSERT INTO json_placeholder.utenti (id, nome, email, data_creazione) VALUES (1, 'Gianni Test', 'gianni@example.com', '2026-05-08 11:58:00.891913+00');


--
-- TOC entry 3466 (class 0 OID 0)
-- Dependencies: 223
-- Name: posts_id_seq; Type: SEQUENCE SET; Schema: json_placeholder; Owner: docker
--

SELECT pg_catalog.setval('json_placeholder.posts_id_seq', 1, false);


--
-- TOC entry 3467 (class 0 OID 0)
-- Dependencies: 221
-- Name: utenti_id_seq; Type: SEQUENCE SET; Schema: json_placeholder; Owner: docker
--

SELECT pg_catalog.setval('json_placeholder.utenti_id_seq', 1, true);


--
-- TOC entry 3307 (class 2606 OID 16420)
-- Name: posts posts_pkey; Type: CONSTRAINT; Schema: json_placeholder; Owner: docker
--

ALTER TABLE ONLY json_placeholder.posts
    ADD CONSTRAINT posts_pkey PRIMARY KEY (id);


--
-- TOC entry 3303 (class 2606 OID 16406)
-- Name: utenti uni_email; Type: CONSTRAINT; Schema: json_placeholder; Owner: docker
--

ALTER TABLE ONLY json_placeholder.utenti
    ADD CONSTRAINT uni_email UNIQUE (email);


--
-- TOC entry 3305 (class 2606 OID 16404)
-- Name: utenti utenti_pkey; Type: CONSTRAINT; Schema: json_placeholder; Owner: docker
--

ALTER TABLE ONLY json_placeholder.utenti
    ADD CONSTRAINT utenti_pkey PRIMARY KEY (id);


-- Completed on 2026-05-08 12:23:49 UTC

--
-- PostgreSQL database dump complete
--

\unrestrict yAhPIyf1Nqb5Bmdhnyeje21EkJbZ1gZ7dLNx70dNTwva1kic3sU83dpn2tykxvD

