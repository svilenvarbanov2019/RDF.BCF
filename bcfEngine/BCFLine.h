#pragma once

#include "BCFObject.h"
#include "XMLPoint.h"
struct BCFViewPoint;


struct BCFLine : public BCFObject
{
public:
    BCFLine(BCFViewPoint& viewPoint, ListOfBCFObjects* parentList);

    void Read(_xml::_element& elem, const std::string& folder);
    void Write(_xml_writer& writer, const std::string& folder, const char* tag);

public:
    bool GetStartPoint(BCFPoint& pt) { return GetPoint(m_StartPoint, pt); }
    bool GetEndPoint(BCFPoint& pt) { return GetPoint(m_EndPoint, pt); }

    bool SetStartPoint(BCFPoint* pt) { return SetPoint(pt, m_StartPoint); }
    bool SetEndPoint(BCFPoint* pt) { return SetPoint(pt, m_EndPoint); }

private:
    XMLPoint    m_StartPoint;
    XMLPoint    m_EndPoint;
};

