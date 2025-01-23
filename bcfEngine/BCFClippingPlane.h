#pragma once

#include "BCFObject.h"
#include "XMLPoint.h"
struct BCFViewPoint;


struct BCFClippingPlane : public BCFObject
{
public:
    BCFClippingPlane(BCFViewPoint& viewPoint, ListOfBCFObjects* parentList);

    void Read(_xml::_element& elem, const std::string& folder);
    void Write(_xml_writer& writer, const std::string& folder, const char* tag);

public:
    bool GetLocation(BCFPoint& pt) { return GetPoint(m_Location, pt); }
    bool GetDirection(BCFPoint& pt) { return GetPoint(m_Direction, pt); }

    bool SetLocation(BCFPoint* pt) { return SetPoint(pt, m_Location); }
    bool SetDirection(BCFPoint* pt) { return SetPoint(pt, m_Direction); }

private:
    XMLPoint m_Location;
    XMLPoint m_Direction;
};

